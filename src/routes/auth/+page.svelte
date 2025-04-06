<script>
	import { enhance } from '$app/forms';
	import { goto, invalidate } from '$app/navigation';
	import { toast } from '@zerodevx/svelte-toast';

	export let data;

	let isLogin = true;
	let loading = false;
	let error = null;

	let formData = {
		username: '',
		password: '',
		age: ''
	};

	async function handleSubmit() {
		loading = true;
		error = null;

		try {
			const endpoint = isLogin ? '/api/auth/login' : '/api/auth/register';
			const response = await fetch(endpoint, {
				method: 'POST',
				headers: {
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(formData)
			});

			if (response.ok) {
				toast.push(isLogin ? 'Sikeres bejelentkezés' : 'Sikeres regisztráció', {
					theme: {
						'--toastBarBackground': '#4CAF50'
					}
				});
				await invalidate('app:user');
				goto('/books');
				return;
			}

			const data = await response.json();
			throw new Error(data.error || (isLogin ? 'Bejelentkezés sikertelen' : 'Regisztráció sikertelen'));
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
</script>

<div class="ui container">
	<div class="ui middle aligned center aligned grid">
		<div class="column">
			<h2 class="ui header">
				<div class="content">
					{isLogin ? 'Bejelentkezés' : 'Új fiók létrehozása'}
				</div>
			</h2>

			{#if error}
				<div class="ui negative message">
					<div class="header">Hiba</div>
					<p>{error}</p>
				</div>
			{/if}

			<form class="ui large form" on:submit|preventDefault={handleSubmit}>
				<div class="ui stacked segment">
					<div class="required field">
						<div class="ui left icon input">
							<i class="user icon"></i>
							<input
								type="text"
								bind:value={formData.username}
								placeholder="Felhasználónév"
								required
							>
						</div>
					</div>

					<div class="required field">
						<div class="ui left icon input">
							<i class="lock icon"></i>
							<input
								type="password"
								bind:value={formData.password}
								placeholder="Jelszó"
								required
							>
						</div>
					</div>

					{#if !isLogin}
						<div class="required field">
							<div class="ui left icon input">
								<i class="calendar icon"></i>
								<input
									type="number"
									bind:value={formData.age}
									placeholder="Életkor"
									min="1"
									max="150"
									required
								>
							</div>
						</div>
					{/if}

					<button
						class="ui fluid large primary submit button"
						type="submit"
						class:loading
						disabled={loading}
					>
						{isLogin ? 'Bejelentkezés' : 'Regisztráció'}
					</button>
				</div>
			</form>

			<div class="ui message">
				{#if isLogin}
					Még nincs fiókod? <button class="ui button link" on:click={() => (isLogin = false)}>Regisztráció</button>
				{:else}
					Már van fiókod? <button class="ui button link" on:click={() => (isLogin = true)}>Bejelentkezés</button>
				{/if}
			</div>
		</div>
	</div>
</div>

<style>
	.grid {
		height: 100vh;
	}
	
	.column {
		max-width: 450px;
	}
</style> 