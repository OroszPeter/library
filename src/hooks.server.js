import { validateSessionToken, sessionCookieName } from '$lib/server/auth';
import { db } from '$lib/server/db';
import { user } from '$lib/server/db/schema';
import { eq } from 'drizzle-orm';

export const handle = async ({ event, resolve }) => {
	const sessionToken = event.cookies.get(sessionCookieName);
	
	if (sessionToken) {
		const { user: sessionUser } = await validateSessionToken(sessionToken);
		if (sessionUser) {
			const [dbUser] = await db.select().from(user).where(eq(user.id, sessionUser.id));
			event.locals.user = dbUser;
		} else {
			event.locals.user = null;
		}
	} else {
		event.locals.user = null;
	}

	return resolve(event);
};
