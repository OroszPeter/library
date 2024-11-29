<script>
    export let nightMode = false;
    let night_Mode = false;
    import { nightMode as nightModeStore } from '../store.js';

    // Lenyíló menü állapota
    let isMenuOpen = false;

    function toggleLight() {
        nightModeStore.update(mode => !mode);
        night_Mode = !night_Mode;
    }

    function toggleMenu() {
        isMenuOpen = !isMenuOpen;
    }
</script>

<div class="{night_Mode ? 'nightMode' : ''} navbar-container">
    <nav class="{night_Mode ? 'nightMode' : ''} navbar w-100 py-2">
        <a href="/" class="first-link">
            <b>Bibliotheca Motus Imaginibus</b>
        </a>

        <a href="javascript:void(0);" class="ms-4" on:click={toggleMenu}>
            Menu
        </a>
        <!-- Lenygó tartalom, ha isMenuOpen igaz -->
        {#if isMenuOpen}
            <div class="{night_Mode ? 'nightMode' : ''} dropdown-menu">
                <a href="/movies" class="dropdown-item">Filmek</a>
                <a href="/series" class="dropdown-item">Sorozatok</a>
                <a href="/about" class="dropdown-item">Visszajelzés</a>
            </div>
        {/if}
        
        <!-- Keresőmező, amely mindig látható -->
        <div class="{night_Mode ? 'nightMode' : ''} search-container pe-2">
            <input type="text" placeholder="Keresés. . ." />
            <a href="/result" class="sb"><i class="bi bi-search"></i></a>
        </div>
        
        <!-- Navigációs linkek nagyobb képernyőkre -->
        <div class="nav-links">
            <a href="/watchlist">Watchlist</a>
            <a href="/login">Bejelentkezés</a>
            <a href="" on:click={toggleLight}>CC</a>
        </div>
    </nav>

    <!-- Dropdown menü, amely kis képernyőkön jelenik meg, ha a hamburger menüt lenyomják -->
    <!-- {#if isMenuOpen}
        <div class="{night_Mode ? 'nightMode' : ''} dropdown-menu">
            <a href="/watchlist">Watchlist</a>
            <a href="/login">Bejelentkezés</a>
            <a href="" on:click={toggleLight}>CC</a>
            <a href="/movies">Filmek</a><br>
            <a href="/tv-shows">Sorozatok</a><br>
            <a href="/about">Gyakran ismételt kérdések</a><br>
        </div>
    {/if} -->
</div>

<style>
    @import url('https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,100;0,300;0,400;0,700;0,900&display=swap');

    /* Alap elrendezés és stílusok */
    .navbar-container {
        display: flex;
        flex-direction: column;
        align-items: center;
        width: 100%;
    }

    /* .navbar módosítása */
nav.navbar {
    display: flex;
    align-items: center;
    justify-content: flex-start; /* Balra igazítja a tartalmat */
    background-color: #FF7D29;
    padding: 0.5rem 1rem;
    width: 100%;
    gap: 20px; /* Távolságot ad a linken és a menü többi elem között */
}

/* Kisebb képernyőkön a nav-links és a többi elem közötti távolság */
.nav-links {
    display: flex;
    flex-direction: row;
    gap: 10px; /* Csökkentett gap érték a linkek között */
    margin-left: 20px; /* Távolság a "Bibliotheca Motus Imaginibus" linktől */
}

    a {
        text-decoration: none;
        color: #FEFFD2;
        font-family: "Lato", sans-serif;
        font-weight: 400;
        font-size: 20px;
    }

    .first-link {
        font-size: 1.2rem;
    }

    /* Keresősáv stílusai */
    .search-container {
        width: 750px;
        display: flex;
        align-items: center;
        background-color: #FFF2D7;
        border-radius: 10px;
        padding: 1px 10px;
    }

    input[type="text"] {
        border: none;
        background: none;
        outline: none;
        color: inherit;
        padding: 5px;
    }

    /* Hamburger ikon kisebb kijelzőkön */
    .menu-toggle {
        display: none;
        font-size: 1.5rem;
        cursor: pointer;
    }

    /* Éjszakai mód háttér és színek */
    .nightMode {
        background-color: black !important;
    }

    .nightMode a {
        color: white;
    }

    .nightMode .first-link {
        color: red;
    }

    .nightMode input, .nightMode .bi {
        background-color: black;
        color: white;
    }

    .nightMode .sb {
        color: white;
    }

    .nightMode .search-container {
        background-color: #444;
        border: 1px solid white;
    }

    /* Dropdown menü stílusai */
    .dropdown-menu {
        width: 97.5%;
        background-color: #FF7D29;
        padding: 10px;
        border-radius: 5px;
        position: absolute;
        top: 52.5px;

        z-index: 9999;
        display: flex;
        flex-direction: column;
        gap: 10px;
    }
    .bi{
        color: #FF7D29;
    }

    /* Reszponzív stílusok */
   
    /* Tablethez és mobilhoz (max 1024px) */
    @media (max-width: 1024px) {
        .nav-links {
            display: none; /* Navigációs linkek elrejtése kisebb képernyőkön */
        }

        .menu-toggle {
            display: block;
            color: #FEFFD2;
        }

        .search-container {
        max-width: 750px;
        width: 100%;
        margin-top: 0.5rem;
    }

        .first-link {
            font-size: 1rem;
        }
    }

    /* Nagy képernyőkhöz (min 1024px) */
    @media (min-width: 1024px) {
        .navbar {
            display: flex;
            flex-direction: row;
            align-items: center;
            justify-content: space-between;
        }

        .nav-links {
            display: flex;
            flex-direction: row;
            gap: 20px;
        }

        .search-container {
            width: 750px;
        }
        .search-container input {
            width: 100%;
        }

        .menu-toggle {
            display: none;
        }
    }
</style>
