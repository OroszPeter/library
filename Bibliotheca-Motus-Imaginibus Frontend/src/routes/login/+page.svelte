<script>
    import { nightMode } from '../../store.js'; // Importáld a nightMode store-t
    import { onMount } from 'svelte'; // Opcióként, ha szükség van rá

    let isNightMode; // Változó a sötét mód állapotához

    // Subscribe a nightMode store-hoz
    nightMode.subscribe(value => {
        isNightMode = value;
    });
</script>

<main class="{isNightMode ? 'nightMode' : ''} vh-100">
    <div class="container d-flex justify-content-center pt-3 vh-75">
        <div class="card p-4 h-75" style="width: 300px;">
            <h3 class="text-center mb-4">Bejelentkezés</h3>
            <form>
                <div class="form-group">
                    <label for="username">Felhasználónév</label>
                    <input type="text" class="form-control" id="username" placeholder="Felhasználónév" required>
                </div>
                <div class="form-group">
                    <label for="password">Jelszó</label>
                    <input type="password" class="form-control" id="password" placeholder="Jelszó" required>
                </div>
                <div class="d-flex flex-column justify-content-center">
                    <a class="btn my-2">Bejelentkezés</a>
                </div>
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
    a:hover {
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
