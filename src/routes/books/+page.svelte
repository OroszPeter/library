<script>
	import { page } from '$app/stores';
	import { toast } from '@zerodevx/svelte-toast';
	
	export let data;
	
	let searchTerm = '';
	let selectedGenre = '';
	let sortOrder = 'title';
	
	$: genres = [...new Set(data.books.map(book => book.genre))];
	
	$: filteredBooks = data.books
		.filter(book => 
			(searchTerm === '' || 
			book.title.toLowerCase().includes(searchTerm.toLowerCase()) ||
			book.author.toLowerCase().includes(searchTerm.toLowerCase())) &&
			(selectedGenre === '' || book.genre === selectedGenre)
		)
		.sort((a, b) => {
			if (sortOrder === 'title') return a.title.localeCompare(b.title);
			if (sortOrder === 'author') return a.author.localeCompare(b.author);
			if (sortOrder === 'publishYear') return b.publishYear - a.publishYear;
			if (sortOrder === 'pageCount') return b.pageCount - a.pageCount;
			return 0;
		});
</script>

<div class="ui container">
	<h1 class="ui header">Könyvek</h1>

	<div class="ui segment">
		<div class="ui form">
			<div class="three fields">
				<div class="field">
					<label>Keresés</label>
					<div class="ui icon input">
						<input 
							type="text" 
							bind:value={searchTerm} 
							placeholder="Cím vagy szerző..."
							aria-label="Keresés"
						>
						<i class="search icon"></i>
					</div>
				</div>
				<div class="field">
					<label>Műfaj</label>
					<select 
						class="ui dropdown" 
						bind:value={selectedGenre}
						aria-label="Műfaj szűrés"
					>
						<option value="">Összes műfaj</option>
						{#each genres as genre}
							<option value={genre}>{genre}</option>
						{/each}
					</select>
				</div>
				<div class="field">
					<label>Rendezés</label>
					<select 
						class="ui dropdown" 
						bind:value={sortOrder}
						aria-label="Rendezés"
					>
						<option value="title">Cím szerint</option>
						<option value="author">Szerző szerint</option>
						<option value="publishYear">Kiadási év szerint</option>
						<option value="pageCount">Oldalszám szerint</option>
					</select>
				</div>
			</div>
		</div>
	</div>

	{#if filteredBooks.length > 0}
		<div class="ui four cards">
			{#each filteredBooks as book}
				<a class="ui card" href="/books/{book.id}">
					<div class="image">
						<img src={book.imageUrl || 'https://via.placeholder.com/400x600?text=Nincs+Kép'} alt={book.title}>
					</div>
					<div class="content">
						<div class="header">{book.title}</div>
						<div class="meta">
							<span>{book.author}</span>
						</div>
					</div>
				</a>
			{/each}
		</div>
	{:else}
		<div class="ui placeholder segment">
			<div class="ui icon header">
				<i class="search icon"></i>
				Nem található könyv a megadott feltételekkel
			</div>
		</div>
	{/if}
</div>

<style>
	.ui.cards {
		margin-top: 1rem;
	}
	
	.ui.card .image {
		height: 300px;
		overflow: hidden;
	}
	
	.ui.card .image img {
		width: 100%;
		height: 100%;
		object-fit: cover;
	}
	
	.ui.card .content {
		padding: 1rem;
	}
	
	.ui.card .header {
		font-size: 1.2em;
		margin-bottom: 0.5rem;
	}
	
	.ui.card .meta {
		color: rgba(0,0,0,.6);
	}
</style> 