import { createBrowserRouter } from 'react-router-dom'
import { Home } from './pages/home'
import { Details } from './pages/details'
import { Create } from './pages/create'
import { Edit } from './pages/edit'

export const router = createBrowserRouter([
  {
    path: '/',
    element: <Home />,
  },
  {
    path: '/create',
    element: <Create />,
  },
  {
    path: '/details/:id',
    element: <Details />,
  },
  {
    path: '/edit/:id',
    element: <Edit />,
  },
])
