#include <iostream>
#include <fstream>
using namespace std;
struct Node {
    int data;
    Node* next;
    Node* prev;
};
void createList(Node*& head, Node*& tail, int n) {
    head = NULL;
    tail = NULL;
    for (int i = 0; i < n; i++) {
        Node* newNode = new Node;
        cout << "Введите элемент " << i + 1 << ": ";
        cin >> newNode->data;
        newNode->next = NULL;
        newNode->prev = tail;
        if (tail != NULL) {
            tail->next = newNode;
        }
        tail = newNode;
        if (head == NULL) {
            head = newNode;
        }
    }
    cout << "Список успешно создан!" << endl;
}
void addNode(Node*& head, Node*& tail, int key) {
    Node* newNode = new Node;
    cout << "Введите новый элемент: ";
    cin >> newNode->data;
    newNode->next = NULL;
    newNode->prev = NULL;
    if (head == NULL) {
        head = newNode;
        tail = newNode;
    }
    else {
        Node* current = head;
        while (current != NULL && current->data != key) {
            current = current->next;
        }
        if (current == NULL) {
            cout << "Такого элемента нет в вашем списке!" << endl;
            return;
        }
        if (current->prev != NULL) {
            newNode->prev = current->prev;
            current->prev->next = newNode;
        }
        else {
            head = newNode;
        }
        newNode->next = current;
        current->prev = newNode;
    }
    cout << "Элемент успешно добавлен!" << endl;
}
void deleteNode(Node*& head, Node*& tail, int pos, int k) {
    if (head == NULL) {
        cout << "Список пуст!" << endl;
        return;
    }
    Node* current = head;
    int count = 1;
    while (current != NULL && count < pos) {
        current = current->next;
        count++;
    }
    if (current == NULL) {
        cout << "Позиция не найдена!" << endl;
        return;
    }
    for (int i = 0; i < k; i++) {
        if (current->prev != NULL) {
            current->prev->next = current->next;
        }
        else {
            head = current->next;
        }
        if (current->next != NULL) {
            current->next->prev = current->prev;
        }
        else {
            tail = current->prev;
        }
        Node* temp = current;
        current = current->next;
        delete temp;
    }
    cout << "Элемент успешно удален!" << endl;
}
void printList(Node* head) {
    cout << "Содержание списка: ";
    Node* current = head;
    while (current != NULL) {
        cout << current->data << " ";
        current = current->next;
    }
    cout << endl;
}
void writeListToFile(Node* head, string fileName) {
    ofstream outFile(fileName);
    if (outFile.is_open()) {
        Node* current = head;
        while (current != NULL) {
            outFile << current->data << " ";
            current = current->next;
        }
        cout << "Список успешно записан в файл!" << endl;
    }
    else {
        cout << "Ошибка открытия файла" << endl;
    }
    outFile.close();
}
void destroyList(Node*& head, Node*& tail) {
    Node* current = head;
    while (current != NULL) {
        Node* temp = current;
        current = current->next;
        delete temp;
    }
    head = NULL;
    tail = NULL;
    cout << "Список успешно удален!" << endl;
}
void readListFromFile(Node*& head, Node*& tail, string fileName) {
    ifstream inFile(fileName);
    if (inFile.is_open()) {
        destroyList(head, tail);
        int data;
        while (inFile >> data) {
            Node* newNode = new Node;
            newNode->data = data;
            newNode->next = NULL;
            newNode->prev = tail;
            if (tail != NULL) {
                tail->next = newNode;
            }
            tail = newNode;
            if (head == NULL) {
                head = newNode;
            }
        }
        cout << "Список успешно прочитан из файла!" << endl;
    }
    else {
        cout << "Ошибка открытия файла!" << endl;
    }
}
int main()
{
    setlocale(0, "RUS");
    Node* head = NULL;
    Node* tail = NULL;
    int n, key, pos, k;
    string fileName;
    cout << "Введите количество элементов списка: ";
    cin >> n;
    createList(head, tail ,n);
    printList(head);
    cout << "Введите ключ для добавления элемента перед: ";
    cin >> key;
    addNode(head, tail, key);
    printList(head);
    cout << "Введите позицию, с которой нужно удалить: ";
    cin >> pos;
    cout << "Введите количество элементов для удаления: ";
    cin >> k;
    deleteNode(head, tail, pos, k);
    printList(head);
    cout << "Введите имя файла для записи списка: ";
    cin >> fileName;
    writeListToFile(head, fileName);
    destroyList(head, tail);
    cout << "Введите имя файла для чтения списка: ";
    cin >> fileName;
    readListFromFile(head, tail, fileName);
    printList(head);
    return 0;
}
