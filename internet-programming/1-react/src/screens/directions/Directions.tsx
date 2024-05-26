import { IDirection } from '../../shared/types/direction.types'
import { items } from './directions.data'
import type { TableProps } from 'antd'
import { FC, useEffect } from 'react'
import { Table } from 'antd'

const columns: TableProps<IDirection>['columns'] = [
  {
    title: 'Квалификация',
    dataIndex: 'qualification',
    key: 'qualification',
    onCell: (_, index) => ({
      rowSpan: index === 0 ? 2 : index === 2 ? 5 : 0,
    }),
  },
  {
    title: 'Направление',
    dataIndex: 'direction',
    key: 'direction',
  },
  {
    title: 'Профиль',
    dataIndex: 'profile',
    key: 'profile',
  },
]

const Directions: FC = () => {
  useEffect(() => {
    document.title = 'Направления'
  }, [])

  return <Table pagination={false} columns={columns} dataSource={items} scroll={{ x: true }} />
}

export default Directions
