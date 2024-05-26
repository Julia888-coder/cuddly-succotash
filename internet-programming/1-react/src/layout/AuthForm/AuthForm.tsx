import { Button, Form, Input } from 'antd'
import type { FormProps } from 'antd'
import { FC } from 'react'

type FieldType = {
  phone?: string
  password?: string
}

const AuthForm: FC = () => {
  const onFinish: FormProps<FieldType>['onFinish'] = (values) => {
    window.alert(`Телефон: ${values.phone}\nПароль: ${values.password}`)
  }

  const onFinishFailed: FormProps<FieldType>['onFinishFailed'] = () => {
    window.alert('Ошибка! Проверьте ввод данных')
  }

  return (
    <Form
      name="auth"
      layout="vertical"
      onFinish={onFinish}
      onFinishFailed={onFinishFailed}
      style={{ padding: '20px' }}
    >
      <Form.Item<FieldType>
        label="Телефон"
        name="phone"
        rules={[{ required: true, message: 'Пожалуйста, введите телефон!' }]}
      >
        <Input type="tel" />
      </Form.Item>

      <Form.Item<FieldType>
        label="Пароль"
        name="password"
        rules={[{ required: true, message: 'Пожалуйста, введите пароль!' }]}
      >
        <Input.Password />
      </Form.Item>

      <Form.Item style={{ textAlign: 'center' }}>
        <Button type="primary" htmlType="submit">
          Войти
        </Button>
      </Form.Item>
    </Form>
  )
}

export default AuthForm
