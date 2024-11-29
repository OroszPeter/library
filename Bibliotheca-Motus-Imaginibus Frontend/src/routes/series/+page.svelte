<script>
    import { onMount } from 'svelte';
    import { nightMode } from '../../store.js'; // Importáld a nightMode store-t

    let isRendered = false; // Ezzel az állapottal biztosíthatod, hogy csak egyszer renderelje a komponenst.

    onMount(() => {
        isRendered = true; // Ha betöltődött, egyszerűen `true` értékre állítjuk.
    });
</script>
<main class="{ $nightMode ? 'nightMode' : '' }">
    <h1 class="pt-5 ps-3 pb-3">Sorozatok</h1>
    <h3 class="ps-3">Kategória 1</h3>
    <div id="carouselExample1" class="carousel slide" data-bs-interval="false">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <div class="d-flex justify-content-around gap-3"> <!-- A justify-content-around egyenlő távolságot biztosít -->
                    {#each Array(5).fill(0) as _, index}
                        <div class="col text-center carousel-item-wrapper">
                            <img src="https://i.twic.pics/v1/placeholder:500x600" class="d-block" alt="Kép {index + 1}">
                            <div class="carousel-caption position-static">
                                <h5  class="{ $nightMode ? 'nightMode' : '' } nfs-h5">Cím {index + 1}</h5>
                            </div>
                        </div>
                    {/each}
                </div>
            </div>
            <div class="carousel-item">
                <div class="d-flex justify-content-around gap-3">
                    {#each Array(5).fill(0) as _, index}
                        <div class="col text-center carousel-item-wrapper">
                            <img src="https://i.twic.pics/v1/placeholder:500x600" class="d-block" alt="Kép {index + 6}">
                            <div class="carousel-caption position-static">
                                <h5 class="{ $nightMode ? 'nightMode' : '' } nfs-h5">Cím {index + 6}</h5>
                            </div>
                        </div>
                    {/each}
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

    <h3 class="ps-3">Kategória 2</h3>
    <div id="carouselExample2" class="carousel slide" data-bs-interval="false">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <div class="d-flex justify-content-around gap-3"> <!-- A justify-content-around egyenlő távolságot biztosít -->
                    {#each Array(5).fill(0) as _, index}
                        <div class="col text-center carousel-item-wrapper">
                            <img src="https://i.twic.pics/v1/placeholder:500x600" class="d-block" alt="Kép {index + 1}">
                            <div class="carousel-caption position-static">
                                <h5  class="{ $nightMode ? 'nightMode' : '' } nfs-h5">Cím {index + 1}</h5>
                            </div>
                        </div>
                    {/each}
                </div>
            </div>
            <div class="carousel-item">
                <div class="d-flex justify-content-around gap-3">
                    {#each Array(5).fill(0) as _, index}
                        <div class="col text-center carousel-item-wrapper">
                            <img src="https://i.twic.pics/v1/placeholder:500x600" class="d-block" alt="Kép {index + 6}">
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

    <h3 class="ps-3">Kategória 2</h3>
    <div id="carouselExample3" class="carousel slide" data-bs-interval="false">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <div class="d-flex justify-content-around gap-3"> <!-- A justify-content-around egyenlő távolságot biztosít -->
                    {#each Array(5).fill(0) as _, index}
                        <div class="col text-center carousel-item-wrapper">
                            <img src="https://i.twic.pics/v1/placeholder:500x600" class="d-block" alt="Kép {index + 1}">
                            <div class="carousel-caption position-static">
                                <h5  class="{ $nightMode ? 'nightMode' : '' } nfs-h5">Cím {index + 1}</h5>
                            </div>
                        </div>
                    {/each}
                </div>
            </div>
            <div class="carousel-item">
                <div class="d-flex justify-content-around gap-3">
                    {#each Array(5).fill(0) as _, index}
                        <div class="col text-center carousel-item-wrapper">
                            <img src="https://i.twic.pics/v1/placeholder:500x600" class="d-block" alt="Kép {index + 6}">
                            <div class="carousel-caption position-static">
                                <h5 class="{ $nightMode ? 'nightMode' : '' } nfs-h5">Cím {index + 6}</h5>
                            </div>
                        </div>
                    {/each}
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
</main>
<style>
    @import url('https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,100;0,300;0,400;0,700;0,900&display=swap');
    main {
        background-color: #FFF2D7;
        transition: background-color 0.3s; 
    }

    h1, h3, h5 {
        color: #FFBF78;
        font-family: "Lato", sans-serif;
        font-weight: 400;
    }
    .nightMode {
        background-color: #444444; /* Háttérszín sötét módban */
    }
    .nightMode h1, .nightMode h3 {
        color: red;
    }
     /* Carousel kép stílus */
     .carousel-inner .col img {
        max-height: 310px;
    }

    /* Második Carousel cím elhelyezésének stílusa */
    .carousel-caption.position-static {
        position: static; /* Rögzített helyzetben jeleníti meg a címeket a képek alatt */
        color: #333; /* Címek színe */
        font-size: 1rem;
        padding-top: 5px;
    }
    .nightMode.nfs-h5{
        color: white;
    }

    /* Új stílus az egyenlő távolságokhoz */
    .carousel-item-wrapper {
        padding: 0 10px; /* Margó a képek körül */
        flex: 1 1 0; /* Egyenlő arányú oszlopszélesség */
    }
</style>