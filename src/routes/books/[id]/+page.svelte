<script>
	import { page } from '$app/stores';
	import { onMount } from 'svelte';
	import { goto } from '$app/navigation';

	export let data;

	let book = data.book;
	let loading = true;
	let error = null;

	onMount(async () => {
		try {
			const response = await fetch(`/api/books/${$page.params.id}`);
			if (!response.ok) throw new Error('A könyv nem található');
			book = await response.json();
		} catch (e) {
			error = e.message;
		} finally {
			loading = false;
		}
	});

	async function handleDelete() {
		if (confirm('Biztosan törölni szeretnéd ezt a könyvet?')) {
			try {
				const response = await fetch(`/api/books/${$page.params.id}`, {
					method: 'DELETE'
				});

				if (response.ok) {
					goto('/books');
				} else {
					console.error('Nem sikerült törölni a könyvet');
				}
			} catch (error) {
				console.error('Hiba történt a könyv törlésekor:', error);
			}
		}
	}
</script>

<div class="ui container">
	{#if loading}
		<div class="ui active centered inline loader"></div>
	{:else if error}
		<div class="ui negative message">
			<div class="header">Hiba</div>
			<p>{error}</p>
		</div>
	{:else}
		<div class="ui grid">
			<div class="four wide column">
				<img 
					src={book.imageUrl || 'https://via.placeholder.com/400x600?text=No+Image'} 
					alt={book.title}
					class="ui large image"
				>
			</div>
			<div class="twelve wide column">
				<h1 class="ui header">{book.title}</h1>
				<div class="ui divider"></div>
				
				<div class="ui list">
					<div class="item">
						<i class="user icon"></i>
						<div class="content">
							<strong>Szerző:</strong> {book.author}
						</div>
					</div>
					<div class="item">
						<i class="calendar icon"></i>
						<div class="content">
							<strong>Megjelent:</strong> {book.publishYear}
						</div>
					</div>
					<div class="item">
						<i class="bookmark icon"></i>
						<div class="content">
							<strong>Műfaj:</strong> {book.genre}
						</div>
					</div>
					<div class="item">
						<i class="info circle icon"></i>
						<div class="content">
							<strong>Leírás:</strong>
							<p>{book.description || 'Nincs elérhető leírás.'}</p>
						</div>
					</div>
				</div>

				{#if $page.data.user && $page.data.user.id === book.userId}
					<div class="ui divider"></div>
					<div class="ui buttons">
						<a href="/books/{book.id}/edit" class="ui primary button">
							<i class="edit icon"></i>
							Szerkesztés
						</a>
						<button class="ui negative button" on:click={handleDelete}>
							<i class="trash icon"></i>
							Törlés
						</button>
					</div>
				{/if}
			</div>
		</div>
	{/if}
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