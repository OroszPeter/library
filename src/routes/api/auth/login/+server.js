import { json } from '@sveltejs/kit';
import { db } from '$lib/server/db';
import { user } from '$lib/server/db/schema';
import { eq } from 'drizzle-orm';
import { generateSessionToken, createSession, sessionCookieName } from '$lib/server/auth';
import argon2 from '@node-rs/argon2';

export async function POST({ request, cookies }) {
	const { username, password } = await request.json();

	try {
		// Find user
		const [dbUser] = await db.select().from(user).where(eq(user.username, username));
		if (!dbUser) {
			return json({ error: 'Érvénytelen felhasználónév vagy jelszó' }, { status: 400 });
		}

		// Verify password
		const validPassword = await argon2.verify(dbUser.passwordHash, password);
		if (!validPassword) {
			return json({ error: 'Érvénytelen felhasználónév vagy jelszó' }, { status: 400 });
		}

		// Create session
		const token = generateSessionToken();
		const session = await createSession(token, dbUser.id);
		
		// Set cookie
		cookies.set(sessionCookieName, token, {
			path: '/',
			expires: session.expiresAt
		});

		// Return user data without sensitive information
		const { passwordHash, ...userData } = dbUser;
		return json({ success: true, user: userData });
	} catch (error) {
		console.error('Bejelentkezési hiba:', error);
		return json({ error: 'Ismeretlen hiba történt' }, { status: 500 });
	}
} 