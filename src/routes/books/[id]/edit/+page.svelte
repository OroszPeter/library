<script>
	import { enhance } from '$app/forms';
	import { goto } from '$app/navigation';
	import { page } from '$app/stores';
	import { toast } from '@zerodevx/svelte-toast';

	export let data;

	let loading = false;
	let error = null;
	let formData = { ...data.book };

	const genres = [
		'Fiction',
		'Non-Fiction',
		'Science Fiction',
		'Fantasy',
		'Mystery',
		'Thriller',
		'Romance',
		'Horror',
		'Biography',
		'History',
		'Science',
		'Technology'
	];

	async function handleSubmit() {
		loading = true;
		error = null;

		try {
			const response = await fetch(`/api/books/${data.book.id}`, {
				method: 'PUT',
				headers: {
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(formData)
			});

			if (response.ok) {
				toast.push('Könyv sikeresen frissítve', {
					theme: {
						'--toastBarBackground': '#4CAF50'
					}
				});
				goto(`/books/${data.book.id}`);
				return;
			}

			const responseData = await response.json();
			throw new Error(responseData.error || 'Nem sikerült frissíteni a könyvet');
		} catch (err) {
			console.error('Hiba:', err);
			error = err.message;
			toast.push(error, {
				theme: {
					'--toastBarBackground': '#F44336'
				}
			});
		} finally {
			loading = false;
		}
	}

	async function handleDelete() {
		if (!confirm('Are you sure you want to delete this book?')) return;

		try {
			const response = await fetch(`/api/books/${data.book.id}`, {
				method: 'DELETE'
			});

			if (!response.ok) {
				const data = await response.json();
				throw new Error(data.message || 'Failed to delete book');
			}

			goto('/books');
		} catch (e) {
			error = e.message;
		}
	}
</script>

<div class="ui container">
	<h1 class="ui header">Könyv szerkesztése</h1>

	{#if error}
		<div class="ui error message">
			<p>{error}</p>
		</div>
	{/if}

	<div class="ui grid">
		<div class="four wide column">
			<img 
				src={formData.imageUrl || 'https://via.placeholder.com/400x600?text=No+Image'} 
				alt="Book cover"
				class="ui large image"
			>
		</div>
		<div class="twelve wide column">
			<form class="ui form" on:submit|preventDefault={handleSubmit}>
				<div class="field">
					<label for="title">Cím</label>
					<input 
						type="text" 
						id="title" 
						bind:value={formData.title} 
						required
					>
				</div>

				<div class="field">
					<label for="author">Szerző</label>
					<input 
						type="text" 
						id="author" 
						bind:value={formData.author} 
						required
					>
				</div>

				<div class="field">
					<label for="genre">Műfaj</label>
					<input 
						type="text" 
						id="genre" 
						bind:value={formData.genre} 
						required
					>
				</div>

				<div class="field">
					<label for="publishYear">Kiadás éve</label>
					<input 
						type="number" 
						id="publishYear" 
						bind:value={formData.publishYear} 
						min="1" 
						max={new Date().getFullYear()} 
						required
					>
				</div>

				<div class="field">
					<label for="pageCount">Oldalszám</label>
					<input 
						type="number" 
						id="pageCount" 
						bind:value={formData.pageCount} 
						min="1" 
						required
					>
				</div>

				<div class="field">
					<label for="description">Leírás</label>
					<textarea 
						id="description" 
						bind:value={formData.description} 
						rows="3"
					></textarea>
				</div>

				<div class="field">
					<label for="imageUrl">Borítókép URL</label>
					<input 
						type="url" 
						id="imageUrl" 
						bind:value={formData.imageUrl} 
						placeholder="https://..."
					>
				</div>

				<button class="ui primary button" type="submit" disabled={loading}>
					{loading ? 'Mentés...' : 'Mentés'}
				</button>
				<a href="/books/{data.book.id}" class="ui button">Mégse</a>
			</form>
		</div>
	</div>
</div>

<style>
	.ui.container {
		margin-top: 2rem;
	}
	
	.ui.large.image {
		max-width: 100%;
		height: auto;
	}
</style> 