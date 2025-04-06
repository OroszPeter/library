import { db } from '$lib/server/db';
import { books } from '$lib/server/db/schema';
import { eq } from 'drizzle-orm';

export async function load({ params, locals }) {
	try {
		const [book] = await db.select().from(books).where(eq(books.id, parseInt(params.id)));
		
		if (!book) {
			return {
				status: 404,
				error: new Error('Book not found')
			};
		}

		// Check if the user is authorized to edit this book
		if (!locals.user || book.userId !== locals.user.id) {
			return {
				status: 403,
				error: new Error('Unauthorized to edit this book')
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