## الگوریتم TWR

درالگوریتم TWR زمان ارسال سیگنال UWB RF را اندازه می‌گیریم و فاصله بین دو نود را با ضرب این زمان در سرعت نور به دست می‌آوریم.

برای محاسبه فاصله سه پیام باید ارسال گردد:
- شروع کار با Tag است که TWR را با فرستان پیام poll به آدرس مشخص Anchor آغاز می‌کند. زمان این حرکت آغازین به Time of Sending Poll (TSP) موسوم است.
- در مرحله بعدی Anchor زمان دریافت poll را ذخیره می‌کند Time of Recieving Poll (TRP) و با پیام response در زمان Time of Sending Response (TSR) کار را ادامه می‌دهد.
- با رسیدن response به Tag زمان Time of Recieving Response (TRR) را ذخیره می‌کند و پیام نهایی را ارسال می‌کند که شامل ID, TSP, TRR, TSF می‌باشد.

در نهایت Anchor با استفاده از Time of Reception of Final message (TRF) و اطلاعات موجود در پیام آخر زمان پرواز سیگنال UWB را مشخص می‌سازد.
<p align="center">
<img width="376" alt="Screenshot 1404-01-26 at 11 02 48" src="https://github.com/user-attachments/assets/d40b997c-cd7f-46e5-9f87-937eb9b900b4" />
</p>

## الگوریتم multilateration

برای محاسبه مکان با استفاده از فاصله های به دست آمده باید از الگوریتم multilateration استفاده کنیم. در واقع اگر y_i ها فاصله های اندازه‌گیری شده از Anchor شماره i ام باشد برای پیدا کردن نقطه بهینه x باید مسئله بهینه‌سازی زیر را حل کنیم:

<p align="center">
<img width="297" alt="Screenshot 1404-01-26 at 11 46 35" src="https://github.com/user-attachments/assets/b98d6a53-1f95-4ae4-ab9e-95457c24f550" />
</p>

تا به بهترین شکل بر فاصله های اندازه‌گیری شده منطبق شویم. 

## کلیت روش انجام پروژه 

ماژول های anchor و tag را به صورت ترد های مجزا پیاده سازی کرده و ارتباط بین آن ها را با استفاده از اتصال TCP برقرار می‌سازیم. با توجه به این که تاخیر شبکه بزرگتر از زمان پرواز پیام های UWB می‌باشد، تاخیر هایی که باید انجام شود را همراه با خود پیام ارسال می‌کنیم و گیرنده به جای محاسبه تفاضل زمان ارسال و دریافت پیام تاخیر موجود در پیام را با زمان ارسال پیام جمع می‌زند تا زمان دریافت پیام را به دست آورد. سپس همه anchor ها فاصله را محاسبه کرده و به master anchor می‌فرستند تا با استفاده از الگوریتم multilateration موقعیت مکانی را پیدا کند.
