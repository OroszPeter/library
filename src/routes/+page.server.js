import { db } from '$lib/server/db';
import { books, users } from '$lib/server/db/schema';

export async function load() {
	try {
		// Get total books count
		const [{ count: totalBooks }] = await db
			.select({ count: db.fn.count() })
			.from(books);

		// Get total users count
		const [{ count: totalUsers }] = await db
			.select({ count: db.fn.count() })
			.from(users);

		// Get unique genres count
		const allBooks = await db.select({ genre: books.genre }).from(books);
		const uniqueGenres = new Set(allBooks.map(book => book.genre));
		const totalGenres = uniqueGenres.size;

		return {
			stats: {
				totalBooks,
				totalUsers,
				totalGenres
			}
		};
	} catch (error) {
		console.error('Hiba a statisztikák betöltésekor:', error);
		return {
			stats: {
				totalBooks: 0,
				totalUsers: 0,
				totalGenres: 0
			}
		};
	}
} 