import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { AuthProvider } from './components/context/AuthProvider.tsx'
import { ThemeProvider } from './components/context/ThemeProvider.tsx'

createRoot(document.getElementById('root')!).render(
  <AuthProvider>
    <ThemeProvider defaultTheme="light" storageKey="vite-ui-theme">
          <StrictMode>
            <App />
          </StrictMode>
    </ThemeProvider>
  </AuthProvider>
)
