import {
	mysqlTable,
	int,
	varchar,
	datetime,
	text,
	year
} from 'drizzle-orm/mysql-core';

export const user = mysqlTable('user', {
	id: varchar('id', { length: 255 }).primaryKey(),
	age: int('age'),
	username: varchar('username', { length: 32 }).notNull().unique(),
	passwordHash: varchar('password_hash', { length: 255 }).notNull()
});

export const session = mysqlTable('session', {
	id: varchar('id', { length: 255 }).primaryKey(),
	userId: varchar('user_id', { length: 255 }).notNull().references(() => user.id),
	expiresAt: datetime('expires_at').notNull()
});

export const books = mysqlTable('books', {
	id: int('id').autoincrement().primaryKey(),
	title: varchar('title', { length: 255 }).notNull(),
	author: varchar('author', { length: 255 }).notNull(),
	genre: varchar('genre', { length: 100 }).notNull(),
	publishYear: year('publish_year').notNull(),
	description: text('description'),
	imageUrl: varchar('image_url', { length: 1000 }),
	pageCount: int('page_count').notNull(),
	userId: varchar('user_id', { length: 255 }).references(() => user.id),
	createdAt: datetime('created_at').notNull().default(new Date())
});
