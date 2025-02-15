import { getAppsettings } from "./models/settings";

export async function fetchBackend(path: string, init?: RequestInit) {
    const settings = await getAppsettings();
    return await fetch(`${settings.serverUrl}${path}`, init);
}
