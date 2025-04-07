import { json } from '@sveltejs/kit';
import { db } from '$lib/server/db';
import { books } from '$lib/server/db/schema';
import { eq } from 'drizzle-orm';

export async function GET({ url }) {
	try {
		const allBooks = await db.select().from(books);
		return json(allBooks);
	} catch (error) {
		console.error('Hiba a könyvek lekérésekor:', error);
		return json({ error: 'Nem sikerült lekérni a könyveket' }, { status: 500 });
	}
}

export async function POST({ request, locals }) {
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

		const result = await db.insert(books).values({
			...bookData,
			userId: locals.user.id,
			createdAt: new Date()
		});

		const [newBook] = await db.select()
			.from(books)
			.where(eq(books.id, result.insertId));

		return json(newBook);
	} catch (error) {
		console.error('Hiba a könyv létrehozásakor:', error);
		return json({ error: 'Nem sikerült létrehozni a könyvet' }, { status: 500 });
	}
} 