import { Outlet } from 'react-router-dom'
import './App.css'
import { Header } from './components/index'

function App() {

  return (
    <div className='w-full block'>
      <Header />
      <main>
        <Outlet></Outlet>
      </main>
    </div>
  )
}

export default App
