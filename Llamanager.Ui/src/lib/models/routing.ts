export type RouteComparer = (route: string, currentPath: string) => boolean;

export const exactRoute: RouteComparer = (route, currentPath) => route === currentPath;

export const isInSection: RouteComparer = (route, currentPath) => currentPath.startsWith(route);