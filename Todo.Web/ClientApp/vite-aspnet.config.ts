import reactRefresh from "@vitejs/plugin-react-refresh";
import { defineConfig } from "vite";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [reactRefresh()],
  clearScreen: false,
  server: {
    port: 3000,
    strictPort: true,
    hmr: {
      host: "localhost",
      port: 5001,
      protocol: "wss",
    },
  },
});
