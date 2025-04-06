import { json } from '@sveltejs/kit';
import { db } from '$lib/server/db';
import { user } from '$lib/server/db/schema';
import { eq } from 'drizzle-orm';
import { generateSessionToken, createSession, sessionCookieName } from '$lib/server/auth';
import argon2 from '@node-rs/argon2';

export async function POST({ request, cookies }) {
	const { username, password, age } = await request.json();

	try {
		// Check if username already exists
		const [existingUser] = await db.select().from(user).where(eq(user.username, username));
		if (existingUser) {
			return json({ error: 'A felhasználónév már foglalt' }, { status: 400 });
		}

		// Create user
		const userId = crypto.randomUUID();
		const passwordHash = await argon2.hash(password);
		await db.insert(user).values({
			id: userId,
			username,
			age: parseInt(age),
			passwordHash
		});

		// Create session
		const token = generateSessionToken();
		const session = await createSession(token, userId);
		
		// Set cookie
		cookies.set(sessionCookieName, token, {
			path: '/',
			expires: session.expiresAt
		});

		return json({ success: true });
	} catch (error) {
		console.error('Regisztrációs hiba:', error);
		return json({ error: 'Nem sikerült létrehozni a fiókot' }, { status: 500 });
	}
} 