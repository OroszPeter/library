import { drizzle } from 'drizzle-orm/mysql2';
import mysql from 'mysql2/promise';
import * as schema from './schema';
import { env } from '$env/dynamic/private';

if (!env.DATABASE_URL) throw new Error('DATABASE_URL is not set');

let client;
try {
  const connectionConfig = {
    host: 'db16832.public.databaseasp.net',
    user: 'db16832',
    password: 'M=q8@p9PL#b5',
    database: 'db16832',
    port: 3306,
    ssl: false,
    insecureAuth: true
  };

  client = await mysql.createConnection(connectionConfig);
  
  // Enable connection pooling and set keepalive
  client.on('error', async (err) => {
    console.error('Database error:', err);
    if (err.code === 'PROTOCOL_CONNECTION_LOST') {
      client = await mysql.createConnection(connectionConfig);
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
