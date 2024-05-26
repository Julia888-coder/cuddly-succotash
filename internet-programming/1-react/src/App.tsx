import Directions from './screens/directions/Directions'
import NotFound from './screens/not-found/NotFound'
import { Routes, Route } from 'react-router-dom'
import locale from 'antd/es/locale/ru_RU'
import Home from './screens/home/Home'
import News from './screens/news/News'
import { ConfigProvider } from 'antd'
import Layout from './layout/Layout'
import 'antd/dist/reset.css'
import { FC } from 'react'

const App: FC = () => {
  return (
    <ConfigProvider
      locale={locale}
      theme={{
        token: {
          colorBgLayout: '#ffffff',
          colorBgBase: '#ece8e8',
          colorTextBase: '#222222',
        },
      }}
    >
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Home />} />
          <Route path="news" element={<News />} />
          <Route path="directions" element={<Directions />} />
          <Route path="*" element={<NotFound />} />
        </Route>
      </Routes>
    </ConfigProvider>
  )
}

export default App
