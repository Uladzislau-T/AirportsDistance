import React from 'react';
import './App.css';
import Navbar from './components/navbar/navbar';
import { Route, Routes } from 'react-router-dom';
import { routes } from './core/routes';

function App() {
  return (
    <div className="App">
      <Navbar />
      <Routes>
        {Object.values(routes).map((route) => {  
          return (
            <Route
              key={`route-${route.path}`}
              path={route.path}
              element={<route.Element />}
            />
          );
        })}
      </Routes>
    </div>
  );
}

export default App;
