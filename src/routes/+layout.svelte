<script>
	import { page } from '$app/stores';
	import { goto } from '$app/navigation';
	import { invalidate } from '$app/navigation';
	import { SvelteToast, toast } from '@zerodevx/svelte-toast';

	export let data;
	$: user = $page.data.user;

	const toastOptions = {
		duration: 4000,
		pausable: true,
		theme: {
			'--toastBackground': '#F8F9FA',
			'--toastColor': '#212529',
			'--toastBarBackground': '#4CAF50'
		}
	};

	async function handleLogout() {
		try {
			const response = await fetch('/api/auth/logout', {
				method: 'POST'
			});

			if (response.ok) {
				toast.push('Sikeres kijelentkezés', {
					theme: {
						'--toastBarBackground': '#4CAF50'
					}
				});
				await invalidate('app:user');
				goto('/auth');
			} else {
				throw new Error('Kijelentkezés sikertelen');
			}
		} catch (error) {
			console.error('Hiba a kijelentkezés során:', error);
			toast.push('Hiba történt a kijelentkezés során', {
				theme: {
					'--toastBarBackground': '#F44336'
				}
			});
		}
	}
</script>

<SvelteToast options={toastOptions} />

<svelte:head>
	<title>Könyvtár Alkalmazás</title>
	<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/semantic-ui@2.4.2/dist/semantic.min.css">
</svelte:head>

<div class="ui container">
	<nav class="ui fixed menu">
		<div class="ui container">
			<a href="/" class="item" class:active={$page.url.pathname === '/'}>Kezdőlap</a>
			<a href="/books" class="item" class:active={$page.url.pathname === '/books'}>Könyvek</a>
			{#if $page.data?.user}
				<a href="/books/add" class="item" class:active={$page.url.pathname === '/books/add'}>Új könyv</a>
			{/if}
			
			<div class="right menu">
				{#if user}
					<span class="item">Üdvözöljük, {user.username}!</span>
					<a href="/" class="item" on:click|preventDefault={handleLogout}>Kijelentkezés</a>
				{:else}
					<a href="/auth" class="item" class:active={$page.url.pathname === '/auth'}>Bejelentkezés / Regisztráció</a>
				{/if}
			</div>
		</div>
	</nav>

	<div class="ui segment">
		<slot />
	</div>
</div>

<style>
	:global(body) {
		background-color: #f9f9f9;
		margin-top: 2rem;
	}
</style> 