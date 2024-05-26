import { NavLink } from 'react-router-dom'
import type { MenuProps } from 'antd'

export const items: MenuProps['items'] = [
  {
    label: <NavLink to="/">Главная</NavLink>,
    key: 'home',
  },
  {
    label: <NavLink to="/news">Новости</NavLink>,
    key: 'news',
  },
  {
    label: <NavLink to="/directions">Направления</NavLink>,
    key: 'directions',
  },
]
