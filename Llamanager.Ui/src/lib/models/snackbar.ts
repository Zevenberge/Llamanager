import { writable } from "svelte/store";

type SnackbarProps = {
    message: string;
    type: 'success' | 'error'
};

export const currentNotification = writable<SnackbarProps>();