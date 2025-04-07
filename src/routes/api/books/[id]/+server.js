import { json } from '@sveltejs/kit';
import { db } from '$lib/server/db';
import { books } from '$lib/server/db/schema';
import { eq } from 'drizzle-orm';

export async function GET({ params }) {
	try {
		const [book] = await db.select().from(books).where(eq(books.id, parseInt(params.id)));
		
		if (!book) {
			return json({ error: 'Book not found' }, { status: 404 });
		}

		return json(book);
	} catch (error) {
		return json({ error: 'Failed to fetch book' }, { status: 500 });
	}
}

export async function PUT({ params, request, locals }) {
	if (!locals.user) {
		return json({ error: 'A művelet végrehajtásához be kell jelentkezni' }, { status: 401 });
	}

	try {
		const bookData = await request.json();
		
		// Validate required fields
		const requiredFields = ['title', 'author', 'genre', 'publishYear', 'pageCount'];
		for (const field of requiredFields) {
			if (!bookData[field]) {
				return json({ error: `A ${field} mező kitöltése kötelező` }, { status: 400 });
			}
		}

		// Validate numeric fields
		if (isNaN(bookData.publishYear) || bookData.publishYear < 1 || bookData.publishYear > new Date().getFullYear()) {
			return json({ error: 'Érvénytelen kiadási év' }, { status: 400 });
		}

		if (isNaN(bookData.pageCount) || bookData.pageCount < 1) {
			return json({ error: 'Érvénytelen oldalszám' }, { status: 400 });
		}

		// Check if book exists and belongs to user
		const [existingBook] = await db.select()
			.from(books)
			.where(eq(books.id, parseInt(params.id)));

		if (!existingBook) {
			return json({ error: 'A könyv nem található' }, { status: 404 });
		}

		if (existingBook.userId !== locals.user.id) {
			return json({ error: 'Nincs jogosultságod a könyv szerkesztéséhez' }, { status: 403 });
		}

		// Prepare update data without date fields
		const updateData = {
			title: bookData.title,
			author: bookData.author,
			genre: bookData.genre,
			publishYear: bookData.publishYear,
			pageCount: bookData.pageCount,
			description: bookData.description,
			imageUrl: bookData.imageUrl
		};

		await db.update(books)
			.set(updateData)
			.where(eq(books.id, parseInt(params.id)));

		const [updatedBook] = await db.select()
			.from(books)
			.where(eq(books.id, parseInt(params.id)));

		return json(updatedBook);
	} catch (error) {
		console.error('Hiba a könyv frissítésekor:', error);
		return json({ error: 'Nem sikerült frissíteni a könyvet' }, { status: 500 });
	}
}

export async function DELETE({ params, locals }) {
	if (!locals.user) {
		return json({ error: 'A művelet végrehajtásához be kell jelentkezni' }, { status: 401 });
	}

	try {
		const [existingBook] = await db.select()
			.from(books)
			.where(eq(books.id, params.id));

		if (!existingBook) {
			return json({ error: 'A könyv nem található' }, { status: 404 });
		}

		if (existingBook.userId !== locals.user.id) {
			return json({ error: 'Nincs jogosultságod a könyv törléséhez' }, { status: 403 });
		}

		await db.delete(books)
			.where(eq(books.id, params.id));

		return json({ success: true });
	} catch (error) {
		console.error('Hiba a könyv törlésekor:', error);
		return json({ error: 'Nem sikerült törölni a könyvet' }, { status: 500 });
	}
} 