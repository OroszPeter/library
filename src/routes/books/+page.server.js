import { db } from '$lib/server/db';
import { books } from '$lib/server/db/schema';

export async function load() {
	try {
		const allBooks = await db.select().from(books);
		
		// Extract unique genres
		const genres = [...new Set(allBooks.map(book => book.genre))];
		
		// Extract unique decades
		const decades = [...new Set(allBooks.map(book => Math.floor(book.publishYear / 10) * 10))].sort();

		return {
			books: allBooks,
			genres,
			decades
		};
	} catch (error) {
		console.error('Failed to fetch books:', error);
		return {
			books: [],
			genres: [],
			decades: []
		};
	}
} 