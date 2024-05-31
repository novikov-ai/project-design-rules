# Простые правила проектного дизайна

1. избавляться от точек генерации исключений, запрещая соответствующее ошибочное поведение на уровне интерфейса класса;
   1. [Пример 1](RemoveExceptions/Example1/README.md)
   2. [Пример 2](RemoveExceptions/Example2/README.md)
2. отказаться от дефолтных конструкторов без параметров, и передавать конструктору обязательные аргументы;
   1. [Пример 1](RemoveDefaultConstructors/Example1/README.md)
   2. [Пример 2](RemoveDefaultConstructors/Example2/README.md)
3. избегать увлечения примитивными типами данных, разрабатывать прикладную систему типов, на смысловом уровне моделирующую предметную область (используйте типы данных Клетка и Фигура, а не строки или числа).
   1. [Пример 1](RemovePrimitivesDataStructures/Example1/README.md)
   2. [Пример 2](RemovePrimitivesDataStructures/Example2/README.md)