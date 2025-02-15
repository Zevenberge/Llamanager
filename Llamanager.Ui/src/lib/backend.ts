import { getAppsettings } from "./models/settings";

export async function fetchBackend(path: string, init?: RequestInit, fetch?: typeof globalThis.fetch) {
    const settings = await getAppsettings(fetch);
    return await (fetch ?? globalThis.fetch)(`${settings.serverUrl}${path}`, init);
}
