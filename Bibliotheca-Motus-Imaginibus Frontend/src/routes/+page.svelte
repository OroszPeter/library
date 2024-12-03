<script>
    import { nightMode, isLoggedIn, userStore } from '../store.js'; // Importáljuk a nightMode store-t
    import { onMount } from 'svelte';

    let user = {};

    let isRendered = false; // Ezzel az állapottal biztosíthatod, hogy csak egyszer renderelje a komponenst.

    onMount(() => {
        isRendered = true; // Ha betöltődött, egyszerűen `true` értékre állítjuk.
    });
    function logout(event) {
        event.preventDefault(); // Megakadályozza az alapértelmezett linkre kattintás viselkedést (újratöltés)

        if (typeof window !== "undefined") {
            localStorage.removeItem("jwtToken"); // Törli a jwtToken-t
            localStorage.removeItem("loginTime"); // Törli a bejelentkezési időt
            localStorage.clear(); // Eltávolít minden adatot a localStorage-ból
        }

        isLoggedIn.set(false); // Beállítjuk, hogy a felhasználó ki van jelentkezve
        userStore.set({ username: "", email: "" }); // Ürítjük a userStore-t
        window.location.href = "/"; // Átirányítás a főoldalra
    }

     // Figyeljük a userStore-t, és frissítjük a user adatokat
     $: userStore.subscribe((value) => {
        user = value;
    });

    let isMenuOpen = false;
    function toggleMenu() {
        isMenuOpen = !isMenuOpen;
    }
</script> 

{#if isRendered}
<main class="{ $nightMode ? 'nightMode' : '' } ">
    <div class="{ $nightMode ? 'nightMode' : '' } container mt-5 welcome px-5">
        <div class="{ $nightMode ? 'nightMode' : '' }" id="left">
            <h1 class="pt-5 pb-5 ps-5">Köszöntjük az oldalon!</h1>
        <p class="ps-5 pb-5">Bibliotheca Motus Imaginibus, mozgóképek tárháza. Itt filmeket és sorozatokat találhat minden mennyiségben.</p>
        </div>
        {#if $isLoggedIn}
        <div id="right" class="pt-5 text-center { $nightMode ? 'nightMode' : '' }">
            <h5 class="pt-5">Bejelentkezve, mint:</h5>
        <p>{user.userName}</p>
        <a href="/" class="p-1 register" on:click={logout}>Kijelentkezés</a>
        </div>
        {:else}
        <div id="right" class="pt-5 text-center { $nightMode ? 'nightMode' : '' }">
            <h5>Már van fiókod?</h5>
            <a href="/login" class="p-1 register">Bejelentkezés</a>
            <p>vagy</p>
            <h5 class="">Regisztrálj!</h5>
        <p>Szeretnél Watchlistet létrehozni? Esetleg megosztanád véleményed?</p>
        <a href="/register" class="p-1 register">Regisztráció</a>
        </div>
        {/if}
    </div>
    <div class="container">
        <!-- Első Carousel (3 képpel) -->
        <h1 class="pt-5 ps-3">Új filmek</h1>
        <div id="carouselExample1" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <div class="d-flex justify-content-center">
                        <a href="/movie" class="img">
                            <img src="/matrix.png" class="d-block w-100" alt="Kép 1">
                        </a>
                    </div>
                    <div class="carousel-caption position-static">
                        <h5>Film 1</h5>
                    <p>Műfaj</p>
                </div>
            </div>
            <div class="carousel-item">
                <div class="d-flex justify-content-center">
                    <a href="/movie" class="img">
                        <img src="https://via.placeholder.com/800x400" class="d-block w-100" alt="Kép 2">
                    </a>
                </div>
                <div class="carousel-caption position-static">
                    <h5>Film 2</h5>
                    <p>Műfaj</p>
                </div>
            </div>
            <div class="carousel-item">
                <div class="d-flex justify-content-center">
                    <a href="/movie" class="img">
                        <img src="https://via.placeholder.com/800x400" class="d-block w-100" alt="Kép 3">
                    </a>
                </div>
                <div class="carousel-caption position-static">
                    <h5>Film 3</h5>
                    <p>Műfaj</p>
                </div>
            </div>
        </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample1" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Előző</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample1" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Következő</span>
            </button>
        </div>

        <h1 class="pt-5 ps-3">Új sorozatok</h1>
        <div id="carouselExample3" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <div class="d-flex justify-content-center">
                        <a href="/movie" class="img">
                            <img src="https://via.placeholder.com/800x400" class="d-block w-100" alt="Kép 1">
                        </a>
                    </div>
                    <div class="carousel-caption position-static">
                        <h5>Sorozat 1</h5>
                        <p>Műfaj</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <div class="d-flex justify-content-center">
                        <a href="/movie" class="img">
                            <img src="https://via.placeholder.com/800x400" class="d-block w-100" alt="Kép 2">
                        </a>
                    </div>
                    <div class="carousel-caption position-static">
                        <h5>Sorozat 2</h5>
                        <p>Műfaj</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <div class="d-flex justify-content-center">
                        <a href="/movie" class="img">
                            <img src="https://via.placeholder.com/800x400" class="d-block w-100" alt="Kép 3">
                        </a>
                    </div>
                    <div class="carousel-caption position-static">
                        <h5>Sorozat 3</h5>
                        <p>Műfaj</p>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample3" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Előző</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample3" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Következő</span>
            </button>
        </div>

        <h1 class="pt-5 ps-3">Népszerű filmek, sorozatok</h1>
        <div id="carouselExample2" class="carousel slide" data-bs-interval="false">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <div class="d-flex justify-content-around gap-3"> <!-- A justify-content-around egyenlő távolságot biztosít -->
                        {#each Array(5).fill(0) as _, index}
                            <div class="col text-center carousel-item-wrapper">
                                <a href="/movie" class="sm">
                                    <img src="https://i.twic.pics/v1/placeholder:500x600" class="d-block small" alt="Kép {index + 1}">
                                </a>
                                <div class="carousel-caption position-static">
                                    <h5 class="{ $nightMode ? 'nightMode' : '' } nfs-h5">Cím {index + 1}</h5>
                                </div>
                            </div>
                        {/each}
                    </div>
                </div>
                <div class="carousel-item">
                    <div class="d-flex justify-content-around gap-3">
                        {#each Array(5).fill(0) as _, index}
                            <div class="col text-center carousel-item-wrapper">
                                <a href="/movie" class="sm">
                                    <img src="https://i.twic.pics/v1/placeholder:500x600" class="d-block small" alt="Kép {index + 6}">
                                </a>
                                <div class="carousel-caption position-static">
                                    <h5 class="{ $nightMode ? 'nightMode' : '' } nfs-h5">Cím {index + 6}</h5>
                                </div>
                            </div>
                        {/each}
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample2" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Előző</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample2" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Következő</span>
            </button>
        </div>
    </div>
</main>
{/if}

<style>
    img{
        border: 20px dashed black;
    }
    .img{
            border-width: 15px;
            border-style: double;
            Border-color: black;
    }
    .sm{
        border: 5px dashed black;
    }
    .small{
            border: 5px dotted black;
    }
    
    main{
        background-color: #FFF2D7; /* Eredeti háttérszín */
    }
    body {

        transition: background-color 0.3s, color 0.3s; /* Színváltozás animálása */
    }
    .nightMode {
        background-color: #444444; /* Háttérszín sötét módban */
        color: #ffffff; /* Szöveg színe sötét módban */
    }

    h1, h5 {
        color: #FFBF78; /* Cím színe világos módban */
    }

    .nightMode h1, .nightMode h5 {
        color: red; /* Cím színe sötét módban */
    }

/* A carousel vezérlő gombjainak pozicionálása kívülre */
.carousel-control-prev, .carousel-control-next {
    position: absolute;
    top: 50%;
    transform: translateY(-50%);
    z-index: 10;
    width: 5%; /* Szélesség csökkentése */
}

.carousel-control-prev {
    left: -5%; /* Balra tolás */
}

.carousel-control-next {
    right: -5%; /* Jobbra tolás */
}

/* A képek szélén egy kis margó */
.carousel-inner {
    padding-left: 10%;
    padding-right: 10%;
}

/* Carousel képek stílusa */
.carousel-inner .col img {
    max-height: 250px;
    object-fit: cover; /* Kép kitöltése a rendelkezésre álló helyet */
}

/* Sötét mód esetén */
.nightMode .carousel-caption.position-static {
    color: white; /* Felirat színe sötét módban */
}
.welcome{
    /* border: solid, 1px, #FF7D29; */
    border-radius: 25px;
    display: flex;
    justify-content: space-between; /* Igazítja őket a két szélen */
    background-color: #FF7D29;
}
#left {
  width: 48%; /* Kb. 50% szélesség a bal oldali elemnek */
}

#right {
  width: 48%; /* Kb. 50% szélesség a jobb oldali elemnek */
}
.register{
    background-color: #FFBF78;
    color: #FFF2D7;
    text-decoration: none;
    border-radius: 10px; 
}
p{
    color: #FFF2D7;
}
</style>
