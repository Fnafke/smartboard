import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import { AuthProvider } from './components/context/AuthProvider.tsx'
import { ThemeProvider } from './components/context/ThemeProvider.tsx'
import { createBrowserRouter, createRoutesFromElements, Route, RouterProvider } from 'react-router-dom'
import HomePage from './Pages/Homepage/index.tsx'
import LoginPage from './Pages/Loginpage/index.tsx'

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route path='/' element={<HomePage />} />
      <Route path='/login' element={<LoginPage />} />
    </>
  )
)

createRoot(document.getElementById('root')!).render(
  <AuthProvider>
    <ThemeProvider defaultTheme="light" storageKey="vite-ui-theme">
          <StrictMode>
            <RouterProvider router={router} />
          </StrictMode>
    </ThemeProvider>
  </AuthProvider>
)
