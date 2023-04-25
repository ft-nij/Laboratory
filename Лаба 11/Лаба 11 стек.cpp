#include <iostream>
#include <fstream>
using namespace std;
struct Node // структура узла стека
{
    int key; // ключевое поле
    Node* next; // указатель на следующий элемент
};
void createStack(Node*& top) // создание пустого стека
{
    top = NULL;
}
void push(Node*& top, int key) // добавление элемента в стек
{
    Node* p = new Node; // создаем новый элемент
    p->next = top;
    p->key = key; // присваиваем ему значение ключа
     // новый элемент становится первым
    top = p; // вершина стека указывает на новый элемент
}
void pop(Node*& top) // удаление верхнего элемента из стека
{
    if (top == NULL) // если стек пустой
    {
        cout << "Стек пустой!" << endl;
        return;
    }
    Node* p = top; // сохраняем вершину стека
    top = top->next; // вершина стека указывает на следующий элемент
    delete p; // удаляем сохраненный элемент
}
void printStack(Node* top) // печать стека
{
    if (top == NULL) // если стек пустой
    {
        cout << "Стек пустой!" << endl;
        return;
    }
    while (top != NULL) // пока не достигнут конец стека
    {
        cout << top->key << " "; // печатаем значение ключа
        top = top->next; // переходим к следующему элементу
    }
    cout << endl;
}
void writeStackToFile(Node* top, string fileName) // запись стека в файл
{
    ofstream file(fileName); // создаем файл для записи
    if (file.is_open()) // если файл открыт
    {
        while (top != NULL) // пока не достигнут конец стека
        {
            file << top->key << " "; // записываем значение ключа
            top = top->next; // переходим к следующему элементу
        }
        file.close(); // закрываем файл
    }
    else // если файл не открыт
    {
        cout << "Ошибка открытия файла!" << endl;
    }
}
void destroyStack(Node*& top) // уничтожение стека
{
    while (top != NULL) // пока не достигнут конец стека
    {
        Node* p = top; // сохраняем вершину стека
        top = top->next; // вершина стека указывает на следующий элемент
        delete p; // удаляем сохраненный элемент
    }
}
void restoreStackFromFile(Node*& top, string fileName) // восстановление стека из файла
{
    destroyStack(top); // уничтожаем существующий стек
    ifstream file(fileName); // открываем файл для чтения
    if (file.is_open()) // если файл открыт
    {
        int key;
        while (file >> key) // пока не достигнут конец файла
        {
            push(top, key); // добавляем элемент в стек
        }
        file.close(); // закрываем файл
    }
    else // если файл не открыт
    {
        cout << "Ошибка открытия файла!" << endl;
    }
}
int main()
{
    setlocale(LC_ALL, "Russian"); // подключаем русский язык
    Node* top; // указатель на вершину стека
    int n, k;
    createStack(top); // создаем пустой стек
    cout << "Введите количество элементов в стеке: ";
    cin >> n;
    for (int i = 0; i < n; i++) // заполняем стек
    {
        int key;
        cout << "Введите элемент " << i + 1 << ": ";
        cin >> key;
        push(top, key); // добавляем элемент в стек
    }
    cout << "Стек: ";
    printStack(top); // печатаем стек
    cout << "Введите элемент, который нужно добавить: ";
    cin >> k;
    push(top, k); // добавляем элемент с заданным номером
    cout << "Стек после добавления элемента: ";
    printStack(top); // печатаем стек
    cout << "Введите количество элементов, которые нужно удалить: ";
    cin >> k;
    for (int i = 0; i < k; i++) // удаляем элементы из конца стека
    {
        pop(top);
    }
    cout << "Стек после удаления элементов: ";
    printStack(top); // печатаем стек
    writeStackToFile(top, "stack.txt"); // записываем стек в файл
    destroyStack(top); // уничтожаем стек
    restoreStackFromFile(top, "stack.txt"); // восстанавливаем стек из файла
    cout << "Стек после восстановления из файла: ";
    printStack(top); // печатаем стек
    destroyStack(top); // уничтожаем стек
    return 0;
}