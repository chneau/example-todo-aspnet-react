import reactRefresh from "@vitejs/plugin-react-refresh";
import { defineConfig } from "vite";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [reactRefresh()],
  base: "/dist/",
  server: {
    hmr: {
      protocol: "ws",
    },
  },
});
