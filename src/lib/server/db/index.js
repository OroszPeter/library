import { drizzle } from 'drizzle-orm/mysql2';
import mysql from 'mysql2/promise';
import * as schema from './schema';
import { env } from '$env/dynamic/private';

if (!env.DATABASE_URL) throw new Error('DATABASE_URL is not set');

const connection = {
  uri: env.DATABASE_URL,
  ssl: {
    rejectUnauthorized: false
  }
};

let client;
try {
  client = await mysql.createConnection(connection);
  
  // Ping to check connection
  await client.ping();
  console.log('Database connected successfully');
} catch (error) {
  console.error('Error connecting to database:', error);
  throw error;
}

export const db = drizzle(client, { schema, mode: 'default' });
