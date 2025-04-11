import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './app/layout/styles.css'
import App from './app/layout/App.tsx'

//React code to create a route and effectively render our app
createRoot(document.getElementById('root')!).render(
  <StrictMode>{/*Way to stay aligned with best practices as we build our react app*/}
    <App />{/*The main component of your React application. It typically contains the overall structure of the interface that will be rendered in the browser.*/}
  </StrictMode>,
)
