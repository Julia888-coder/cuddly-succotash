package com.example.myapplication3.report

import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.myapplication3.AppSingleton
import com.example.myapplication3.db.EntityEntity
import kotlinx.coroutines.flow.MutableStateFlow
import kotlinx.coroutines.flow.StateFlow
import kotlinx.coroutines.flow.update
import kotlinx.coroutines.launch
import kotlinx.serialization.encodeToString
import kotlinx.serialization.json.Json

data class ReportScreenState(
    val reportString: String? = null,
)

class ReportViewModel : ViewModel() {
    private val entityDao = AppSingleton.appDatabase.entitiesDao()

    private val _state = MutableStateFlow(ReportScreenState())
    val state: StateFlow<ReportScreenState> = _state

    /**
     * Здесь логика для вашего отчета
     */
    fun createReport() {
        viewModelScope.launch {
            val entities = entityDao.getEntitiesList()
            val (entitiesWithContract, entitiesWithoutContract) = entities.partition { it.contractConfirmed }
            _state.update {
                it.copy(
                    reportString = "Количество заключенных контрактов: ${entitiesWithContract.count()}\n" +
                            "Количество без контракта: ${entitiesWithoutContract.count()}"
                )
            }
        }
    }
}
