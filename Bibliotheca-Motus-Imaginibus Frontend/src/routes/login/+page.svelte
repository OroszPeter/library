<script>
    import { onMount } from 'svelte'; // Opcióként, ha szükség van rá
    import { authToken, userStore, isLoggedIn, nightMode} from '../../store.js'; // Importáljuk a store-okat
    let userName = ''; // Felhasználónév
    let password = ''; // Jelszó
    let errorMessage = ''; // Hibák megjelenítése
    let isNightMode; // Változó a sötét mód állapotához

    nightMode.subscribe(value => {
        isNightMode = value;
    });
    // Bejelentkezési függvény
    async function handleLogin(event) {
        event.preventDefault();

        const loginData = {
            userName,
            password
        };

        try {
            // API hívás a bejelentkezéshez
            const response = await fetch('https://localhost:7214/api/Account/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(loginData)
            });

            if (response.ok) {
                // Sikeres válasz esetén
                const data = await response.json();

                // Store-ba mentjük a token-t és a felhasználói adatokat
                authToken.set(data.token);
                userStore.set({
                    userName: userName,
                    token: data.token,
                    // Esetleg további felhasználói adatokat is elmenthetsz itt
                });
                isLoggedIn.set(true);

                // Átirányítás a főoldalra vagy egy másik oldalra
                window.location.href = '/'; // Például a /dashboard oldalra irányítunk

            } else {
                // Ha a válasz nem OK, hibát írunk ki
                const errorData = await response.json();
                errorMessage = errorData.message || 'Hiba történt a bejelentkezéskor!';
            }
        } catch (error) {
            // Ha hiba történik az API hívás során
            console.error(error);
            errorMessage = 'Hálózati hiba történt!';
        }
    }
</script>

<main class="{isNightMode ? 'nightMode' : ''} vh-100">
    <div class="container d-flex justify-content-center pt-3 vh-75">
        <div class="card p-4 h-75" style="width: 300px;">
            <h3 class="text-center mb-4">Bejelentkezés</h3>
            <form on:submit={handleLogin}>
                <div class="form-group">
                    <label for="username">Felhasználónév</label>
                    <input type="text" class="form-control" id="username" bind:value={userName} placeholder="Felhasználónév" required>
                </div>
                <div class="form-group">
                    <label for="password">Jelszó</label>
                    <input type="password" class="form-control" id="password" bind:value={password} placeholder="Jelszó" required>
                </div>
                <div class="d-flex flex-column justify-content-center">
                    <button type="submit" class="btn my-2">Bejelentkezés</button>
                </div>

                {#if errorMessage}
                    <div class="alert alert-danger mt-3">
                        {errorMessage}
                    </div>
                {/if}

                <div class="d-flex justify-content-center">
                    <a href="/change-password">Elfelejtetted a jelszavad?</a>
                </div>
                <hr class="my-3">
                <div class="d-flex flex-column justify-content-center">
                    <h5 class="text-center">Nincs fiókod?</h5><br>
                    <a href="/register" class="btn">Regisztráció</a>
                </div>
            </form>
        </div>
    </div>
</main>

<style>
    button{
        color: #FEFFD2;
    }
    main {
        background-color: #FFF2D7; /* Eredeti háttérszín */
        transition: background-color 0.3s; /* Simább átmenet */
    }
    .card, a {
        background-color: #FF7D29; /* Eredeti szín */
        color: #FEFFD2; /* Eredeti szöveg szín */
        font-family: "Lato", sans-serif;
        font-weight: 400;
        font-style: normal;
        text-decoration: none;
    }
    a:hover, button:hover {
        color: whitesmoke; /* Hover szín */
    }
    input {
        outline: none; /* Nincs keret a fókuszban */
    }
    .btn {
        background-color: #FFBF78; /* Gomb háttérszín */
    }
    .nightMode {
        background-color: #444; /* Háttérszín sötét módban */
    }
    .nightMode .card {
        background-color: black; /* Kártya háttérszíne sötét módban */
        color: white; /* Kártya szöveg színe sötét módban */
    }
    .nightMode a {
        background-color: black; /* Link háttérszíne sötét módban */
        color: red; /* Link színe sötét módban */
    }
    .nightMode .btn{
        background-color: #444;
    }
</style>
