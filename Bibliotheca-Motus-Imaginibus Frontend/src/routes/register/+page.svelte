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
    <div class="card p-3" style="width: 300px; height:575px;">
    <h3 class="text-center mb-2">Regisztráció</h3>
    <form>
        <div class="mb-1">
            <label for="vezeteknev" class="form-label">Vezetéknév</label>
            <input type="text" class="form-control" id="vezeteknev" placeholder="Vezetéknév" required>
        </div>
        <div class="mb-1">
            <label for="keresztnev" class="form-label">Keresztnév</label>
            <input type="text" class="form-control" id="keresztnev" placeholder="Keresztnév" required>
        </div>
        <div class="mb-1">
            <label for="email" class="form-label">Email</label>
            <input type="email" class="form-control" id="email" placeholder="Email" required>
        </div>
        <div class="mb-1">
            <label for="jelszo" class="form-label">Jelszó</label>
            <input type="password" class="form-control" id="jelszo" placeholder="Jelszó" required>
        </div>
        <div class="d-flex flex-column justify-content-center">
            <a class="btn my-2">Regisztráció</a>
        </div>
        <hr class="my-3">
        <div class="d-flex flex-column justify-content-center">
            <h5 class="text-center">Már van fiókod?</h5><br>
            <a href="/login" class="btn">Bejelentkezés</a>
        </div>
    </form>
    </div>
</div>
</main>

<style>
    main{
        background-color: #FFF2D7;
    }
    .card, a{
        background-color:  #FF7D29;
        text-decoration: none;
        color: #FEFFD2;
        font-family: "Lato", sans-serif;
        font-weight: 400;
        font-style: normal;
    }
    a:hover{
        color: white;
    }
    input{
        outline: none;
    }
    .btn{
        background-color: #FFBF78;
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