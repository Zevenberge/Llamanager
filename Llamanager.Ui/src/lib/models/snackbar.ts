import { writable } from "svelte/store";

type SnackbarProps = {
    message: string;
    type: 'success' | 'error'
};

export const currentNotification = writable<SnackbarProps>();

type WrapperProps<T> = {
    action: () => Promise<T>,
    onSuccess: string,
    onFailure: string,
}

type WrapperResult<T> = {
    success: true,
    value: T,
} | { success: false }

export async function wrap<T>(props: WrapperProps<T>): Promise<WrapperResult<T>> {
    try {
        const result = await props.action();
        currentNotification.set({
            message: props.onSuccess,
            type: 'success'
        });
        return { success: true, value: result };
    } catch {
        currentNotification.set({
            message: props.onFailure,
            type: 'error'
        });
        return { success: false };
    }
}