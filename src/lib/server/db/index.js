import { drizzle } from 'drizzle-orm/mysql2';
import mysql from 'mysql2/promise';
import * as schema from './schema';
import { env } from '$env/dynamic/private';

if (!env.DATABASE_URL) throw new Error('DATABASE_URL is not set');

let client;
try {
  client = await mysql.createConnection(env.DATABASE_URL);
  
  // Enable connection pooling and set keepalive
  client.on('error', async (err) => {
    console.error('Database error:', err);
    if (err.code === 'PROTOCOL_CONNECTION_LOST') {
      client = await mysql.createConnection(env.DATABASE_URL);
    }
  });

  // Test connection
  await client.query('SELECT 1');
  console.log('Database connected successfully');
} catch (error) {
  console.error('Error connecting to database:', error);
  throw error;
}

export const db = drizzle(client, { schema, mode: 'default' });
