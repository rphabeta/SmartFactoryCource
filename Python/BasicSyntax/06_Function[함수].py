# #------------------------------------------------------------------------------
# # 함수(재 사용성과 유지보수성의 증가)
# # . 반복적인 코드를 작성해두고 언제든지 재 사용 할 수 있도록 할 수 있다. (재사용성)
# # . 함수의 내용을 수정 시 함수를 호출하는 모든 구문의 결과가 일괄 수정된다.  (유지보수성)
# #------------------------------------------------------------------------------
# # 함수의 생성 def
# def MyFunction():
#     print()

# # 함수의 호출
# MyFunction() 


# # 함수의 이수와 인자. (아!수주 받자매파)
# # 함수로 전달하는 값: 인수
# # 함수가 전달받기로 약속한 값: 인자
# def MyFunction(param): # param : 인자(어떠한 값을 받을 수 있는 변수 명)
#     print(param)

# MyFunction("안녕하세요!")

# # 숫자 전달 가능
# def MyFunction(param): # param : 인자(어떠한 값을 받을 수 있는 변수 명)
#     print(param)

# MyFunction(500)

# 잘못된 함수의 호출 (약속된 인자의 값을 전달하지 않았을 경우 오류)
# def MyFunction(param):
#     print(param)

# MyFunction()

# #------------------------------------------------------------------------------
# # 반복되는 구문 함수로 만들기 (리펙토링)
# #------------------------------------------------------------------------------
# # 반복되는 구문 삭제 후 함수로 만들기
# def MyFunction():
#     sum = 0
#     for num in range(5):
#         sum += num
#     print(" ~ 4 합은 : ", sum)

# # 함수가 처리해야 할 상황에 따른 인자 값 설정
# def MyFunction(iValue):
#     sum = 0
#     for num in range(iValue + 1):
#         sum += num
#     print(" ~", iValue, "합은 : ", sum)

# # 함수를 호출하며 테스트
# MyFunction(5)
# MyFunction(6)
# MyFunction(7)
# MyFunction(8)

# # 완성된 결과에서 한 번더 검토.
# def MyFunction(iValue):
#     sum = 0
#     for num in range(iValue + 1):
#         sum += num
#     print(" ~", iValue, "합은 : ", sum)

# # i: 함수를 실행할 때 더해져야하는 함수
# for i in range(5, 9):
#     MyFunction(i)




# # 함수의 내용을 수정할 경우 호출하는 모든 결과를 일괄 수정할 수 있다. (유지보수성)
# def MyFunction(iValue):
#     sum = 1
#     for num in range(1, iValue + 1):
#         sum *= num
#     print(" ~", iValue, "곱은 : ", sum)

# # i: 함수를 실행할 때 곱해져야하는 함수
# for i in range(5, 9):
#     MyFunction(i)


# #------------------------------------------------------------------------------
# # 함수의 결과를 반환하는 return
# # 파이썬의 경우 함수 반환 데이터 유형을 지정하지 않아도 유동적으로 데이터를 
# # 함수를 호출하는 곳으로 반환할 수 있다.
# #------------------------------------------------------------------------------
# # 함수의 결과를 호출한 곳으로 반환함으로써 결과값으로 로직을 이어서 구현하기 위함
# def calsum(end):
#     sum = 0
#     for i in range(end + 1):
#         sum += i
#     return sum

# result = int(input("값을 입력하세요: "))
# print(" 합은 ", calsum(result), " 입니다.")


# # 인자를 n개 생성할 수 있다.
# def calsum(end1, end2, end3):
#     sum = 0
#     for i in range(end1 + 1):
#         sum += i
#     return sum

# calsum(10) # 인자로 인수를 3개 전달해야한다. (오류)

# # pass
# # 로직을 완성하지 않았지만 미완성 로직으로 인해 오류를 잠정적으로 막고 싶을때
# # 인터프리터 언어(프로그램을 실행 할 떄 비로소 오류)
# for i in range(10):
#     pass # 로직의 완성을 미룰때
# print("1")

# #------------------------------------------------------------------------------
# # 실습
# # 1. 정수로 시작 과 끝의 범위 와 몇배수 인지 의 정보를 인자로 받는 함수 를 작성하여
# #    시작 과 끝 범위 내에 있는 배수 를 모두 표현하는 로직을 구현해 보세요
# #------------------------------------------------------------------------------
# def mulFind(init, fin, mul):
#     for i in range(init, fin + 1):
#         if (i % mul == 0):
#             print(i, end=', ')

# init = int(input("시작값: "))
# fin = int(input("끝 값: "))
# mul = int(input("배수: "))
# mulFind(init, fin, mul) 

# # # ver2)
# def Multiprint(sv, ev, mv):
#     message = ''
#     for i in range(sv, ev+1):
#         if i % mv == 0:
#             message += str(i) + ','
#     return message
    
# fValue = int(input("시작값 : "))
# eValue = int(input("종료값 : "))
# mValue = int(input("배수값 : "))
# print(mValue, "의 배수 나열 데이터 : ", Multiprint(fValue, eValue, mValue))


# #------------------------------------------------------------------------------
# # 재귀 호출
# # . 자기 자신을 반복적으로 호출하도록 구현된 함수.
# # . 코드가 간결해지고 가독성이 높아진다.
# # . 일반적으로 풀어내는 로직보다 실행하는데 시간이 오래 걸릴 수 있다.
# # . 반드시 종료하는 시점의 값을 리턴하는 구문이 필요.
# #------------------------------------------------------------------------------
# def factorial(n):
#     if n == 0:
#         return 1
#     else :
#         return n * factorial(n-1)
# result = factorial(5)
# print(result) # 120


