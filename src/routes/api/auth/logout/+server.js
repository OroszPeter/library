import { json } from '@sveltejs/kit';
import { invalidateSession, deleteSessionTokenCookie, sessionCookieName } from '$lib/server/auth';

export async function POST({ cookies }) {
	const sessionToken = cookies.get(sessionCookieName);
	if (!sessionToken) {
		return json({ error: 'Nem vagy bejelentkezve' }, { status: 401 });
	}

	try {
		await invalidateSession(sessionToken);
		deleteSessionTokenCookie({ cookies });
		
		return json({ success: true });
	} catch (error) {
		console.error('Kijelentkezési hiba:', error);
		return json({ error: 'Nem sikerült kijelentkezni' }, { status: 500 });
	}
} 