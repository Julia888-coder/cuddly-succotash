import { Layout as LayoutAntd, Menu } from 'antd'
import AuthForm from './AuthForm/AuthForm'
import { Outlet } from 'react-router-dom'
import styles from './Layout.module.css'
import { items } from './menu.data'
import cn from 'classnames'

const { Header, Footer } = LayoutAntd

const Layout = () => (
  <LayoutAntd className={styles.layout}>
    <Header className={styles.header}>
      <div className="container">
        <Menu className={styles.menu} mode="horizontal" items={items} />
      </div>
    </Header>
    <LayoutAntd className={cn(styles.main, 'container')}>
      <AuthForm />
      <div className={cn(styles.content)}>
        <Outlet />
      </div>
    </LayoutAntd>
    <Footer className={styles.footer}>Выполнил Липатов Илья, ПИбд-41</Footer>
  </LayoutAntd>
)

export default Layout
