import { FC } from "react";
import { DistancePage } from "../modules/Distance/pages/distancePage";


interface RouteItem {
  path: string;
  Element: FC;
  private?: boolean;
}

export const routes: Record<string, RouteItem> = {
  globalFeed: {
    path: '/',
    Element: DistancePage,
  },
  globalFeed2: {
    path: '/home',
    Element: DistancePage,
  }
};
