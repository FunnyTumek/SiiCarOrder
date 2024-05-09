import './App.css';
import { Routes, Route } from 'react-router-dom';
import Layout from './components/Layout';
import CarSelector from './components/indexPage/CarSelector';
import Stepper from './components/configurator/horizontal-stepper/Stepper';
import React from 'react';

function App() {
  
  return (
    <>
      <Routes>
        <Route path='/' element={<Layout />}>
          <Route index element={<CarSelector url={'/api/configuration/available'} />} />
          <Route path='/configurator' element={<Stepper />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
