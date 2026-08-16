import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { AuthProvider } from './components/context/AuthProvider.tsx'
import { SidebarProvider } from './components/ui/sidebar.tsx'
import { TooltipProvider } from './components/ui/tooltip.tsx'
import { ThemeProvider } from './components/context/ThemeProvider.tsx'

createRoot(document.getElementById('root')!).render(
  <AuthProvider>
    <ThemeProvider defaultTheme="light" storageKey="vite-ui-theme">
      <SidebarProvider>
        <TooltipProvider>
          <StrictMode>
            <App />
          </StrictMode>
        </TooltipProvider>
      </SidebarProvider>
    </ThemeProvider>
  </AuthProvider>
)
