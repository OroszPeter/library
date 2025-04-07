import { db } from '$lib/server/db';
import { books } from '$lib/server/db/schema';
import { eq } from 'drizzle-orm';

export async function load({ params }) {
	try {
		const [book] = await db.select().from(books).where(eq(books.id, parseInt(params.id)));
		
		if (!book) {
			return {
				status: 404,
				error: new Error('Book not found')
			};
		}

		return {
			book
		};
	} catch (error) {
		return {
			status: 500,
			error: new Error('Failed to fetch book')
		};
	}
} 