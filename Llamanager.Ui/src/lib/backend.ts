import { getAppsettings } from "./models/settings";

export async function fetchBackend(path: string, init?: RequestInit, fetch?: typeof globalThis.fetch) {
    const settings = await getAppsettings(fetch);
    return await (fetch ?? globalThis.fetch)(`${settings.serverUrl}${path}`, init);
}

function json(method: string) {
    return (body: any) => ({
        method,
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(body),
    }) as RequestInit;
}

export const post = json('post');
export const put = json('put');
export const del = () => ({ method: "delete"});