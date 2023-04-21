#include <iostream>
#include <fstream>
using namespace std;
struct Node {
    int data;
    Node* next;
};
void createList(Node*& head, int n) {
    head = NULL;
    for (int i = 0; i < n; i++) {
        Node* newNode = new Node;
        cout << "Введите элемент " << i + 1 << ": ";
        cin >> newNode->data;
        newNode->next = head;
        head = newNode;
    }
    cout << "Список успешно создан!" << endl;
}
void addNode(Node*& head, int key) {
    Node* newNode = new Node;
    cout << "Введите новый элемент: ";
    cin >> newNode->data;
    if (head == NULL) {
        newNode->next = NULL;
        head = newNode;
    }
    else {
        Node* current = head;
        while (current->next != NULL && current->data != key) {
            current = current->next;
        }
        newNode->next = current->next;
        current->next = newNode;
    }
    cout << "Элемент успешно добавлен!" << endl;
}
void deleteNode(Node*& head, int pos, int k) {
    if (head == NULL) {
        cout << "Список пуст!" << endl;
        return;
    }
    Node* current = head;
    Node* prev = NULL;
    int count = 1;
    while (current != NULL && count < pos) {
        prev = current;
        current = current->next;
        count++;
    }
    if (current == NULL) {
        cout << "Позиция не найдена!" << endl;
        return;
    }
    for (int i = 0; i < k; i++) {
        Node* temp = current;
        current = current->next;
        delete temp;
    }
    if (prev == NULL) {
        head = current;
    }
    else {
        prev->next = current;
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
void destroyList(Node*& head) {
    Node* current = head;
    while (current != NULL) {
        Node* temp = current;
        current = current->next;
        delete temp;
    }
    head = NULL;
    cout << "Список успешно удален!" << endl;
}
void readListFromFile(Node*& head, string fileName) {
    ifstream inFile(fileName);
    if (inFile.is_open()) {
        destroyList(head);
        int data;
        while (inFile >> data) {
            Node* newNode = new Node;
            newNode->data = data;
            newNode->next = head;
            head = newNode;
        }
        cout << "Список успешно прочитан из файла!" << endl;
    }
    else {
        cout << "Ошибка открытия файла" << endl;
    }
    inFile.close();
}
int main() {
    setlocale(0, "RUS");
    Node* head = NULL;
    int n, key, pos, k;
    string fileName;
    cout << "Введите количество элементов списка: ";
    cin >> n;
    createList(head, n);
    printList(head);
    cout << "Введите ключ для добавления элемента перед: ";
    cin >> key;
    addNode(head, key);
    printList(head);
    cout << "Введите позицию, с которой нужно удалить: ";
    cin >> pos;
    cout << "Введите количество элементов для удаления: ";
    cin >> k;
    deleteNode(head, pos, k);
    printList(head);
    cout << "Введите имя файла для записи списка: ";
    cin >> fileName;
    writeListToFile(head, fileName);
    destroyList(head);
    cout << "Введите имя файла для чтения списка: ";
    cin >> fileName;
    readListFromFile(head, fileName);
    printList(head);
    return 0;
}