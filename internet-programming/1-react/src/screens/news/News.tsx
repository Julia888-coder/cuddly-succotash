import { FC, useEffect } from 'react'
import { items } from './news.data'
import { Card, List } from 'antd'

const News: FC = () => {
  useEffect(() => {
    document.title = 'Новости'
  }, [])

  return (
    <>
      <List
        itemLayout="vertical"
        dataSource={items}
        renderItem={(item) => (
          <List.Item>
            <Card type="inner" title={item.title}>
              Автор: {item.author} от {item.date}
            </Card>
          </List.Item>
        )}
      />
    </>
  )
}

export default News
