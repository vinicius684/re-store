import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './app/layout/styles.css'
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import { RouterProvider } from 'react-router-dom';
import { router } from './app/routes/Routes';
import { Provider } from 'react-redux';
import { store } from './app/store/store';


//React code to create a route and effectively render our app
createRoot(document.getElementById('root')!).render(
  <StrictMode>{/*Way to stay aligned with best practices as we build our react app*/}
    <Provider store={store}>
      <RouterProvider router={router} future={{ v7_startTransition: true }} />{/*The main component of your React application. It typically contains the overall structure of the interface that will be rendered in the browser.*/}
    </Provider>
  </StrictMode>,
)
