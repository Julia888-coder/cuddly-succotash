import { FC, useEffect } from 'react'

const NotFound: FC = () => {
  useEffect(() => {
    document.title = 'Ошибка'
  }, [])

  return <h1>Страница не найдена</h1>
}

export default NotFound
