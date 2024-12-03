import { writable } from 'svelte/store';

export const nightMode = writable(false);

// Kezdeti felhasználói adatok a localStorage-ból (ha léteznek)
const isBrowser = typeof window !== 'undefined';

// Kezdeti felhasználó adatok
const storedUser = isBrowser
    ? JSON.parse(localStorage.getItem('user')) || { id: '', firstName: '', lastName: '', email: '', photo: null, roles: [], userName: '' }
    : { id: '', firstName: '', lastName: '', email: '', photo: null, roles: [], userName: '' };

// Felhasználói adatokat tároló store
export const userStore = writable(storedUser);

// Ha a felhasználói adat változik, akkor frissítjük a localStorage-t is
userStore.subscribe((value) => {
    if (isBrowser) {
        localStorage.setItem('user', JSON.stringify(value));
    }
});

// Bejelentkezett állapotot tároló store (localStorage-ból)
export const isLoggedIn = writable(isBrowser ? JSON.parse(localStorage.getItem('isLoggedIn')) || false : false);

// Ha az isLoggedIn változik, akkor frissítjük a localStorage-t is
isLoggedIn.subscribe((value) => {
    if (isBrowser) {
        localStorage.setItem('isLoggedIn', JSON.stringify(value));
    }
});

// Token kezelése: a token tárolása a localStorage-ban és a store-ban
export const authToken = writable(isBrowser ? localStorage.getItem('authToken') || null : null);

// Ha a token változik, akkor frissítjük a localStorage-t is
authToken.subscribe((value) => {
    if (isBrowser) {
        if (value) {
            localStorage.setItem('authToken', value);
        } else {
            localStorage.removeItem('authToken');
        }
    }
});
